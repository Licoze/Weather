using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Weather.BLL.Infrastructure;
using Weather.BLL.Interfaces;
using Weather.Models;

namespace Weather.Controllers.WebApi
{
    public class HistoryController : ApiController
    {
        private IHistoryService _service;
        private IMapper _mapper;

        public HistoryController(IServiceFactory factory, IMapper mapper)
        {
            _service = factory.CreateHistoryService();
            _mapper = mapper;
        }
        // GET: api/History
        public IHttpActionResult Get()
        {
            var resultDto = _service.GetHistory();
            var result = _mapper.Map<List<SearchHistoryViewModel>>(resultDto);
            if (result != null)
                return Json(result);
            return NotFound();
        }

        // GET: api/History/5
        public IHttpActionResult Get(int id)
        {
            var resultDto = _service.GetHistory().FirstOrDefault(x=>x.Id==id);
            var result = _mapper.Map<SearchHistoryViewModel>(resultDto);
            if (result != null)
                return Json(result);
            return NotFound();
        }

    }
}
