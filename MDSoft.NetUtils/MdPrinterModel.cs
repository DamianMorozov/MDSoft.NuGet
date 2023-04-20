// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.NetUtils;

public sealed record MdPrinterModel
{
    #region Public and private fields, properties, constructor

    public string Name { get; set; }
    public string Ip { get; set; }
    public short Port { get; set; }
    public string Password { get; set; }
    public bool PeelOffSet { get; set; }
    public short DarknessLevel { get; set; }
    public string Link => string.IsNullOrEmpty(Ip) ? string.Empty : $"http://{Ip}";
    public HttpStatusCode HttpStatusCode { get; set; }
    public IPStatus PingStatus { get; set; }
    public Exception? HttpStatusException { get; set; }

    public MdPrinterModel()
    {
        Ip = string.Empty;
        Port = 0;
        Password = string.Empty;
        PeelOffSet = false;
        DarknessLevel = 0;
        HttpStatusCode = HttpStatusCode.BadRequest;
        HttpStatusException = null;
    }

    #endregion
}