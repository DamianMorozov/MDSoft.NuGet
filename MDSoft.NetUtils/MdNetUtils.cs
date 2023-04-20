// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using RestSharp;

namespace MDSoft.NetUtils;

public static class MdNetUtils
{
	#region Public and private methods

	public static string GetLocalIpAddress()
	{
		try
		{
			IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					return ip.ToString();
				}
			}
		}
		catch (Exception ex)
		{
			throw new($"Exception in {nameof(GetLocalIpAddress)}", ex);
		}
		return string.Empty;
	}

	public static string GetLocalDeviceName(bool isThrow)
	{
		try
		{
			return Dns.GetHostName();
		}
		catch (Exception ex)
		{
			if (isThrow)
				throw new($"Exception in {nameof(GetLocalDeviceName)}", ex);
		}
		return string.Empty;
	}

	public static string GetLocalMacAddress()
	{
		string macAddresses = string.Empty;
		foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
		{
			if (nic.OperationalStatus == OperationalStatus.Up)
			{
				macAddresses += nic.GetPhysicalAddress().ToString();
				break;
			}
		}
		return macAddresses;
	}

	public static void RequestHttpStatus(MdPrinterModel printer, int timeOut)
	{
		if (printer.HttpStatusCode == HttpStatusCode.OK)
			return;
		printer.HttpStatusCode = HttpStatusCode.BadRequest;
		printer.HttpStatusException = null;
		RestClientOptions options = new(printer.Link)
		{
			UseDefaultCredentials = true,
			ThrowOnAnyError = true,
			MaxTimeout = timeOut,
			RemoteCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };
		using RestClient client = new(options);
		RestRequest request = new();
		try
		{
			RestResponse response = client.GetAsync(request).ConfigureAwait(true).GetAwaiter().GetResult();
			printer.HttpStatusCode = response.StatusCode;
		}
		catch (Exception ex)
		{
			printer.HttpStatusException = ex;
		}
	}

	public static bool RequestPing(MdPrinterModel? printer, int timeOut)
	{
		if (printer is null) return false;
		try
		{
			using Ping ping = new();
			PingReply? pingReply = ping.Send(printer.Ip, timeOut);
			if (pingReply is null) return false;
			return (printer.PingStatus = pingReply.Status) == IPStatus.Success;
		}
		catch (Exception ex)
		{
			printer.HttpStatusException = ex;
			printer.PingStatus = IPStatus.Unknown;
		}
		return false;
	}

    public static string GetPingStatus(IPStatus ipStatus) =>
        ipStatus switch
        {
            IPStatus.Success => MdNetLocalization.Instance.StatusSuccess,
            IPStatus.DestinationNetworkUnreachable => MdNetLocalization.Instance.StatusDestinationNetworkUnreachable,
            IPStatus.DestinationHostUnreachable => MdNetLocalization.Instance.StatusDestinationHostUnreachable,
            IPStatus.DestinationProtocolUnreachable => MdNetLocalization.Instance.StatusDestinationProtocolUnreachable,
            IPStatus.DestinationPortUnreachable => MdNetLocalization.Instance.StatusDestinationPortUnreachable,
            IPStatus.NoResources => MdNetLocalization.Instance.StatusNoResources,
            IPStatus.BadOption => MdNetLocalization.Instance.StatusBadOption,
            IPStatus.HardwareError => MdNetLocalization.Instance.StatusHardwareError,
            IPStatus.PacketTooBig => MdNetLocalization.Instance.StatusPacketTooBig,
            IPStatus.TimedOut => MdNetLocalization.Instance.StatusTimedOut,
            IPStatus.BadRoute => MdNetLocalization.Instance.StatusBadRoute,
            IPStatus.TtlExpired => MdNetLocalization.Instance.StatusTtlExpired,
            IPStatus.TtlReassemblyTimeExceeded => MdNetLocalization.Instance.StatusTtlReassemblyTimeExceeded,
            IPStatus.ParameterProblem => MdNetLocalization.Instance.StatusParameterProblem,
            IPStatus.SourceQuench => MdNetLocalization.Instance.StatusSourceQuench,
            IPStatus.BadDestination => MdNetLocalization.Instance.StatusBadDestination,
            IPStatus.DestinationUnreachable => MdNetLocalization.Instance.StatusDestinationUnreachable,
            IPStatus.TimeExceeded => MdNetLocalization.Instance.StatusTimeExceeded,
            IPStatus.BadHeader => MdNetLocalization.Instance.StatusBadHeader,
            IPStatus.UnrecognizedNextHeader => MdNetLocalization.Instance.StatusUnrecognizedNextHeader,
            IPStatus.IcmpError => MdNetLocalization.Instance.StatusIcmpError,
            IPStatus.DestinationScopeMismatch => MdNetLocalization.Instance.StatusDestinationScopeMismatch,
            IPStatus.Unknown => MdNetLocalization.Instance.StatusUnknown,
            _ => MdNetLocalization.Instance.StatusUnknown
        };

    #endregion
}