﻿namespace lesson11_FabricMarket_DomainModel.Models.FabricProduction
{
    public class Vendor : Entity<long>
    {
        public required string Name { get; set; }
    }
}
