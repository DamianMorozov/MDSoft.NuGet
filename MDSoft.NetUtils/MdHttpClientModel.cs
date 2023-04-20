// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ReSharper disable UnusedMember.Global

namespace MDSoft.NetUtils;

public class MdHttpClientModel : INotifyPropertyChanged
{
    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyRaised([CallerMemberName] string caller = "")
    {
        PropertyChanged?.Invoke(this, new(caller));
    }

    #endregion

    #region Public fields and properties

    private int _timeout;
    public int Timeout
    {
        get => _timeout;
        set
        {
            _timeout = value;
            OnPropertyRaised();
        }
    }

    private Uri _host;
    public Uri Host
    {
        get => _host;
        set
        {
            if (!value.ToString().Contains("http://") && !value.ToString().Contains("https://"))
                value = new("http://" + value);
            _host = value;
            OnPropertyRaised();
        }
    }

    private string _log;
    public string Log
    {
        get => _log;
        set
        {
            _log = value;
            OnPropertyRaised();
        }
    }

    private string _settings;
    public string Settings
    {
        get => _settings;
        set
        {
            _settings = value;
            OnPropertyRaised();
        }
    }

    private string _content;
    public string Content
    {
        get => _content;
        set
        {
            _content = value;
            OnPropertyRaised();
        }
    }

    private bool _isStop;
    public bool IsStop
    {
        get => _isStop;
        set
        {
            _isStop = value;
            OnPropertyRaised();
        }
    }

    private object _locker;

    #endregion

    #region Constructor and destructor

    public MdHttpClientModel()
    {
        SetupDefault();
    }

    public MdHttpClientModel(int timeout, Uri host)
    {
        Setup(timeout, host);
    }

    public void SetupDefault()
    {
        Setup(500, new(@"http://localhost"));
    }

    public void Setup(int timeout, Uri host)
    {
        Timeout = timeout;
        Host = host;
        Content = string.Empty;
        IsStop = true;

        Settings = $"Timeout = [{Timeout}]. Url = [{Host}]";
        Log = string.Empty;
    }

    #endregion

    #region Public and private methods

    public async Task<HttpStatusCode> OpenAsync(MdProxyModel proxy = null)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        HttpStatusCode statusCode = HttpStatusCode.NotFound;
        if (_locker is null)
        {
            _locker = new();
            Settings += Environment.NewLine + $"Use proxy = [{proxy?.Use}]. " + Environment.NewLine;
            IsStop = false;
            try
            {
                using (HttpClient httpClient = await GetHttpClient(proxy))
                {
                    if (IsStop) return statusCode;
                    httpClient.Timeout = TimeSpan.FromMilliseconds(Timeout);
                    HttpResponseMessage response = await httpClient.GetAsync(Host).ConfigureAwait(false);
                    if (IsStop) return statusCode;
                    Log += $"Status code: {response.StatusCode}" + Environment.NewLine;
                    statusCode = response.StatusCode;
                    Content = await response.Content.ReadAsStringAsync();
                    Log += $"response.IsSuccessStatusCode : {response.IsSuccessStatusCode}" + Environment.NewLine;
                }

                Log += "Task finished." + Environment.NewLine;
            }
            catch (Exception ex)
            {
                Log += $"{ex.Message}" + Environment.NewLine;
                Log += $"{ex.StackTrace}" + Environment.NewLine;
                if (ex.InnerException != null)
                    Log += $"{ex.InnerException.Message}" + Environment.NewLine;
            }
            finally
            {
                IsStop = true;
                _locker = null;
            }
        }
        return statusCode;
    }

    public async Task CloseAsync()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        IsStop = true;
    }

    public async Task<HttpClient> GetHttpClient(MdProxyModel proxy = null)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        proxy ??= new();
        if (!proxy.Use)
        {
            return new(new HttpClientHandler { UseProxy = false });
        }

        HttpClientHandler handler = new()
        {
            UseProxy = true,
            Proxy = new WebProxy(proxy.Host),
        };
        HttpClient httpClient = new(handler);
        if (proxy.UseDefaultCredentials)
        {
            handler.UseDefaultCredentials = true;
        }
        else if (!string.IsNullOrWhiteSpace(proxy.Username) && !string.IsNullOrWhiteSpace(proxy.Password))
        {
            handler.PreAuthenticate = false;
            handler.UseDefaultCredentials = false;
            handler.Credentials = !string.IsNullOrWhiteSpace(proxy.Domain)
                ? new(proxy.Username, proxy.Password, proxy.Domain)
                : new NetworkCredential(proxy.Username, proxy.Password);
        }
        return httpClient;
    }

    #endregion
}