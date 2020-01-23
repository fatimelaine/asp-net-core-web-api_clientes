namespace ApiClientes.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Whatsapp { get; set; }
        public string Email { get; set; }
        public bool Mailing { get; set; }
    }
}