namespace SampleEnterprise.Models.DesignPattern.Interfaces {
    internal interface IDevUserRole {
        long Id { get; set; }
        string Name { get; set; }
        byte PriorityLevel { get; set; }
    }
}