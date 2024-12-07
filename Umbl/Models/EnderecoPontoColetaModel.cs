namespace Umbl.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EnderecoPontoColetaModel
    {
        public int Id { get; set; }  // Usando um Id único para chave primária

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Estado { get; set; }
    }
}
