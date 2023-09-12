using PersonRegistryLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PersonRegistryLibrary.Services
{
    public class SessionRegistryManager<T> : IDataAccess<T>
        where T : IRegistryItem, new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
   

        public ReadOnlyCollection<T> Items { get; }

        public SessionRegistryManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }

        public void Add(T item)
        {
            var currentKeys = _session.Keys
                .Where(x => x.Contains(typeof(T).FullName))
                .Select(x => x.Replace($"${typeof(T).FullName}_", "")
                .Cast<int>().OrderByDescending(x => x)).ToArray();

            var itemIndex = currentKeys.Count() == 0 ? 0 : currentKeys.Count();
            var itemKey = $"${typeof(T).FullName}_" + itemIndex;

            item.Id = itemIndex;
            _session.SetString(itemKey.ToString(), JsonConvert.SerializeObject(item));
        }

        public void Remove(T item)
        {
         
        }

        public ReadOnlyCollection<T> GetAll()
        {
            var objectList = new List<T>();

            var keys = _session.Keys.Where(x => x.Contains(typeof(T).FullName));
            foreach (var key in keys)
            {
                objectList.Add(JsonConvert.DeserializeObject<T>(_session.GetString(key)));
            }

            return objectList.AsReadOnly();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
