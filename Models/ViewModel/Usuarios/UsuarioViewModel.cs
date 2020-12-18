using System.ComponentModel.DataAnnotations;
using apiEmprestimoJogos.Models.Entity.Usuarios;
using HashidsNet;

namespace apiEmprestimoJogos.Models.ViewModel.Usuarios
{
    public class UsuarioViewModel
    {
        [Display(Name = "codigo"), Required (ErrorMessage = "Este campo é obrigatório")]
        public string Codigo { get; set; }

        [Display(Name = "senha"), Required (ErrorMessage = "Este campo é obrigatório")]
        public string Senha { get; set; }

        public Usuario MapTo(Usuario usuario)
        {
            if(usuario != null){
                var hashids = new Hashids(Senha);
                var senha = hashids.Encode(1,2,3);

                usuario.Codigo = Codigo;
                usuario.Senha = senha;
            }

            return usuario;
        }
    }
}