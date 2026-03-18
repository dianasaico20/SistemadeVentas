
namespace SalesSystem.Infrastructure.Options
{
   public  class VentasDbOptions
    {
        public const string SectionKey = nameof(VentasDbOptions);
        public string ConectionString { get; set; }
    }
}
