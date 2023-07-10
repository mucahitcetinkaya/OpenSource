using BooksApp.Business.Abstract;
using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Business.Concrete
{
    public class PublisherManager : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherManager(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task CreateAsync(Publisher publisher)
        {
            await _publisherRepository.CreateAsync(publisher);
        }

        public void Delete(Publisher publisher)
        {
            _publisherRepository.Delete(publisher);
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            var result = await _publisherRepository.GetAllAsync();
            return result;
        }

        public async Task<List<Publisher>> GetAllPublishersAsync(bool isDeleted, bool? isActive = null)
        {
            var result = await _publisherRepository.GetAllPublishersAsync(isDeleted, isActive);
            return result;
        }

        public async Task<Publisher> GetByIdAsync(int? id)
        {
            var result = await _publisherRepository.GetByIdAsync(id);
            return result;
        }

        public void Update(Publisher publisher)
        {
            _publisherRepository.Update(publisher);
        }
    }
}
