using System.ComponentModel.DataAnnotations;

namespace Umbl.ViewModels
{
    public class PontoColetaViewModel
    {
        public int Id { get; set; }  // Opcional para criação, obrigatório para atualização

        [Required(ErrorMessage = "Capacidade é obrigatória")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        public EnderecoViewModel Endereco { get; set; }

        [Required(ErrorMessage = "Material Aceito é obrigatório")]
        public string MaterialAceito { get; set; } // Pode ser do tipo string para simplificar o payload
    }

    public class EnderecoViewModel
    {
        [Required(ErrorMessage = "Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Número é obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        public string Estado { get; set; }
    }
}
