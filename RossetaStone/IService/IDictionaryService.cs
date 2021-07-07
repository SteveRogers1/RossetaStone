using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RossetaStone.Models;

namespace RossetaStone.IService
{
    public interface IDictionaryService
    {
        List<Dictionary> GetDictionaries();
        Dictionary GetById(int dictionaryId);
        void Save(Dictionary oDictionary);
        void Update(Dictionary oDictionary);
        string Delete(int dictionaryId);

    }
}
