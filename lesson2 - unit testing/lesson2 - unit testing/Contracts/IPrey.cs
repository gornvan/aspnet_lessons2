namespace lesson2___unit_testing.Contracts
{
    public interface IPrey: IMover
    {
        bool CanRunFrom(IHunter hunter);
    }
}
