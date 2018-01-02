using MessageBoard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBoard.Controllers.Api
{
    public class TopicsController : ApiController
    {
        private IMessageBoardRepository _repo;

        public TopicsController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Topic> Get(bool includeReplies = false)
        {
            IQueryable<Topic> results;

            if(includeReplies)
            {
                results = _repo.GetTopicsIncludingReplies();
            }
            else
            {
                results = _repo.GetTopics();
            }
            return results.OrderByDescending(t => t.CreatedDate)
                .Take(50)
                .ToList();
        }

        //post method need 'FormBody' and as WebAPI should return  httpStatus we are 
        //returning 'Created'
        public HttpResponseMessage Post([FromBody]Topic newTopic)
        {
            if(newTopic.CreatedDate == default(DateTime))
            {
                newTopic.CreatedDate = DateTime.UtcNow;
            }

            try
            {
               if( _repo.AddTopic(newTopic) && _repo.Save())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, newTopic);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }            
        }
    }
}
