using System;

namespace MenuDinamico
{
    public class Menu: IMenu
    {
        public int Id { get; set; }
        public int? MenuPaiId { get; set; }
        public string Url { get; set; }
        public string Descricao { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

    }
}
