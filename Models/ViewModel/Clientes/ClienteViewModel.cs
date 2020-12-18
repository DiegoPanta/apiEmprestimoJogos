using System.ComponentModel.DataAnnotations;
using apiEmprestimoJogos.Models.Entity.Clientes;

namespace apiEmprestimoJogos.Models.ViewModel.Clientes
{
    public class ClienteViewModel
    {
        [Display(Name = "idUsuario"), Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdUsuario { get; set; }

        [Display(Name = "nome"), Required (ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "codigo"), Required (ErrorMessage = "Este campo é obrigatório")]
        public int Codigo { get; set; }

        [Display(Name = "telefone"), Required (ErrorMessage = "Este campo é obrigatório")]
        public string Telefone { get; set; }

        public Cliente MapTo(Cliente cliente)
        {
            if(cliente != null)
            {
                cliente.IdUsuario = IdUsuario;
                cliente.Nome = Nome;
                cliente.Codigo = Codigo;
                cliente.Telefone = Telefone;
            }
            
            return cliente;
        }
    }
}