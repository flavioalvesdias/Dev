using System;

namespace MenuDinamico
{
    public interface IMenu
    {
        int Id { get; }
        int? MenuPaiId { get; }
        string Url { get; }
        string Descricao { get; }
        string Controller { get; }
        string Action { get; }
    }
}
