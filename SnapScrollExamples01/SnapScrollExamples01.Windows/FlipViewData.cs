﻿
namespace SnapScrollExamples01
{
    public class FlipViewData
    {
        public FlipViewData()
        {
            string[] names =
            {
                "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Nineth",
                "Tenth", "Eleventh", "Twelveth", "Thirteenth", "Fourteenth", "Fifteenth", "Sixteenth", 
                "Seventeenth", "Eighteenth", "Nineteenth", "Twentyth", "TwentyFirst", "TwentySecond",
                "TwenthThird", "TwentyFourth", "TwentyFifth"
            };
            for (int i = 0; i < 25; i++)
            {
                var name = i < names.Length ? names[i] : "default";
                var item = new Item { Title = name };
                Collection.Add(item);
            }    
        }

        private readonly ItemCollection _collection = new ItemCollection();

        public ItemCollection Collection
        {
            get
            {
                return _collection;
            }
        }
    }
}
