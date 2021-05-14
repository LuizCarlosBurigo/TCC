using CSBHService.Dominio.Interfaces.Consumidor;
using System.Threading.Tasks;

namespace CSBHService.Dominio.Interfaces.Servico
{
    public interface IServicoEntidade<TMensagem>
        where TMensagem : IMensagemConsumidor
    {
        Task processo(TMensagem mensagemRabbit);
    }
}
