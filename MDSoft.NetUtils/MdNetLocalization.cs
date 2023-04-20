// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.NetUtils;

public sealed class MdNetLocalization
{
    #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static MdNetLocalization _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static MdNetLocalization Instance => LazyInitializer.EnsureInitialized(ref _instance);

    #endregion

    public MdLang Lang { get; set; } = MdLang.Russian;

    #region Public and private fields, properties, constructor

    public string StatusUnknown => Lang == MdLang.English ? "Unknown" : "Нет данных";
    public string StatusSuccess => Lang == MdLang.English ? "Success access" : "Успешный доступ";
    public string StatusDestinationNetworkUnreachable => Lang == MdLang.English ? "Destination network unreachable" : "Сеть назначения недоступна";
    public string StatusDestinationHostUnreachable => Lang == MdLang.English ? "Destination host unreachable" : "Хост назначения недоступен";
    public string StatusDestinationProtocolUnreachable => Lang == MdLang.English ? "Destination protocol unreachable" : "Протокол назначения недоступен";
    public string StatusDestinationPortUnreachable => Lang == MdLang.English ? "Destination port unreachable" : "Порт назначения недоступен";
    public string StatusNoResources => Lang == MdLang.English ? "No resources" : "Нет ресурсов";
    public string StatusBadOption => Lang == MdLang.English ? "Bad option" : "Плохая опция";
    public string StatusHardwareError => Lang == MdLang.English ? "Hardware error" : "Аппаратная ошибка";
    public string StatusPacketTooBig => Lang == MdLang.English ? "Packet too big" : "Слишком большой пакет";
    public string StatusTimedOut => Lang == MdLang.English ? "Timed out" : "Тайм-аут";
    public string StatusBadRoute => Lang == MdLang.English ? "Bad route" : "Плохой маршрут";
    public string StatusTtlExpired => Lang == MdLang.English ? "TTL expired" : "Срок действия истек";
    public string StatusTtlReassemblyTimeExceeded => Lang == MdLang.English ? "TTL reassembly time exceeded" : "Превышено время повторной сборки TTL";
    public string StatusParameterProblem => Lang == MdLang.English ? "Unknown" : "статус";
    public string StatusSourceQuench => Lang == MdLang.English ? "Source quench" : "Устранение источника";
    public string StatusBadDestination => Lang == MdLang.English ? "Bad destination" : "Плохое направление";
    public string StatusDestinationUnreachable => Lang == MdLang.English ? "Destination unreachable" : "Место назначения недостижимо";
    public string StatusTimeExceeded => Lang == MdLang.English ? "Time exceeded" : "Превышено время";
    public string StatusBadHeader => Lang == MdLang.English ? "Bad header" : "Плохой заголовок";
    public string StatusUnrecognizedNextHeader => Lang == MdLang.English ? "Unrecognized next header" : "Нераспознанный следующий заголовок";
    public string StatusIcmpError => Lang == MdLang.English ? "ICMP error" : "Ошибка ICMP";
    public string StatusDestinationScopeMismatch => Lang == MdLang.English ? "Destination scope mismatch" : "Несоответствие области назначения";
    
    #endregion
}