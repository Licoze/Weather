using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject;
using NUnit.Framework;
using Weather.DAL.Infrastructure;
using Weather.DAL.Interfaces;
using Weather.DAL.Models;
using Weather.DAL.Repositories;
using Weather.Tests.Config;


namespace Weather.Tests.DAL.Tests.Repositories
{
    
    [TestFixture]
    class CityRepositoryTests
    {
        private IRepository<City> _repository;
        private WeatherDb _db;
        [OneTimeSetUp]
        public void Setup()
        {
            var kernel = new StandardKernel(new NinjectTestModule());
            _db = kernel.Get<WeatherDb>();
            _repository =new Repository<City>(_db);
        }

        [Test]
        public void AddTest()
        {
            var city=new City()
            {
                Name="TestAdd"
            };
            _repository.Create(city);
            Assert.AreEqual(_db.Entry(city).State,EntityState.Added);
        }
        [Test]
        public void DeleteTest()
        {
            var city = new City()
            {
                Name = "TestDelete"
            };
            _db.Cities.Add(city);
            _db.SaveChanges();
            _repository.Delete(city);
            Assert.AreEqual(_db.Entry(city).State, EntityState.Deleted);
        }
        [Test]
        public void UpdateTest()
        {
            var city = new City()
            {
                Name = "UpdateTest"
            };
            _db.Cities.Add(city);
            _db.SaveChanges();
            city.Name = "Changed";
            _repository.Update(city);
            Assert.AreEqual(_db.Entry(city).State, EntityState.Modified);
        }
        [Test]
        public void GetTest()
        {
            var city = new City()
            {
                Name = "GetTest"
            };
            _db.Cities.Add(city);
            _db.SaveChanges();
            var result=_repository.Get(city.Id);
            Assert.AreEqual(result.Name, city.Name);
        }
        [Test]
        public void GetAllTest()
        {
            var city = new City()
            {
                Name = "GetAllTest"
            };
            _db.Cities.Add(city);
            _db.SaveChanges();
            var results = _repository.GetAll();
            Assert.Greater(results.Count(),1);
        }
    }
}
