namespace lesson2___unit_testing.Contracts
{
    public interface IHunter: IMover
    {
        public bool CanCatch(IPrey prey);
    }
}
