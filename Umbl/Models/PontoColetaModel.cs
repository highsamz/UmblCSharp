using System.ComponentModel.DataAnnotations;

namespace Umbl.Models
{
    public class PontoColetaModel
    {
        public int Id { get; set; }
        public int Capacidade { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int EnderecoId { get; set; }
        public virtual EnderecoPontoColetaModel EnderecoPontoColetaModel { get; set; }
        public List<MaterialAceitoModel> MateriaisAceitos { get; set; } = new List<MaterialAceitoModel>();
    }



}
