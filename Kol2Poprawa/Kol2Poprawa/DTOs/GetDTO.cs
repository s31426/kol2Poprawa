namespace Kol2Poprawa.DTOs;

public class GetDTO
{
    public class characterDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int currentWeight { get; set; }
        public ICollection<BackpackItemsDTO> backpackItems { get; set; }
        public ICollection<TitlesDTO> titles { get; set; }
      
    }
    
    public class BackpackItemsDTO
    {
        public string itemName { get; set; }
        public int itemWeight { get; set; }
        public int amount { get; set; }
      
    }
    
    public class TitlesDTO
    {
        public string title { get; set; }
        public DateTime aquiredAT { get; set; }
    }
}