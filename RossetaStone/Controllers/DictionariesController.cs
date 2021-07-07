using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RossetaStone.IService;
using RossetaStone.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RossetaStone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        IDictionaryService _dictionaryService = null;

        public DictionariesController(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        // GET: api/<DictionariesController>
        [HttpGet]
        public IEnumerable<Dictionary> GetDictionaries()
        {
            return _dictionaryService.GetDictionaries();
        }

        // GET api/<DictionariesController>/5
        [HttpGet("{id}", Name = "Get")]
        public Dictionary Get(int id)
        {
            return _dictionaryService.GetById(id);
                }

        // POST api/<DictionariesController>
        [HttpPost]
        public void SaveOrUpdate([FromForm] Dictionary dictionary)
                    {
            if (dictionary.DictionaryId == 0) 
                        {
                _dictionaryService.Save(dictionary); 
                        }
                        else
                        {
                _dictionaryService.Update(dictionary);
        }
        }

        // DELETE api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _dictionaryService.Delete(id);
        }
    }
}
