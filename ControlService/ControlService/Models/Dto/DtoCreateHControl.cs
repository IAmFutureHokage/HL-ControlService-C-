namespace ControlService.Models.Dto
{
    public class DtoCreateHControl
    {
        public int PostCode { get; set; }
        public int Type { get; set; }
        public DateOnly DateStart { get; set; }
        public int Value { get; set; }
    }
}
