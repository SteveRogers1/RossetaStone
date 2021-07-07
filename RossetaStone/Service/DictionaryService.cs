using System.Collections.Generic;
using System.Linq;
using RossetaStone.Data;
using RossetaStone.IService;
using RossetaStone.Models;

namespace RossetaStone.Service
{
    public class DictionaryService : IDictionaryService
    {
        private readonly ApplicationDbContext _context;
        public DictionaryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string Delete(int dictionaryId)
        {
            var dictionary = _context.Dictionaries.FirstOrDefault(x => x.DictionaryId == dictionaryId);
            if(dictionary != null)
            {
                _context.Dictionaries.Remove(dictionary);
                _context.SaveChanges();
            }
            return "Delete";

        }

        public Dictionary GetById(int dictionaryId)
        {
            return _context.Dictionaries.SingleOrDefault(x => x.DictionaryId == dictionaryId);
        }

        public List<Dictionary> GetDictionaries()
        {
            return _context.Dictionaries.ToList();
        }

        public void Save(Dictionary oDictionary)
        {
            _context.Dictionaries.Add(oDictionary);
            _context.SaveChanges();

        }

        public void Update(Dictionary oDictionary)
        {
            _context.Dictionaries.Update(oDictionary);
            _context.SaveChanges();
        }
    }
}
