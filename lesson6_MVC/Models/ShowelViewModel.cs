using lesson6_MVC.Enums;

namespace lesson6_MVC.Models
{
    public class ShowelViewModel
    {
        public int Id { get; set; }

        public ShowelType Type { get; set; }

        public int HandleLength { get; set; }


        public string BriefInfo => $@"{this.Type} showel, {HandleLength}cm";
    }
}
