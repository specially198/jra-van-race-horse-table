using Microsoft.Extensions.DependencyInjection;

namespace JraVanRaceHorseTable
{
    public interface IFormFactory
    {
        TForm Create<TForm>() where TForm : Form;
    }

    public class FormFactory : IFormFactory
    {
        private readonly IServiceProvider _services;

        public FormFactory(IServiceProvider services)
        {
            _services = services;
        }

        public TForm Create<TForm>() where TForm : Form
        {
            return _services.GetRequiredService<TForm>();
        }
    }
}
