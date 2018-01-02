using MessageBoard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBoard.Controllers.Api
{
    public class RepliesController : ApiController
    {
        private IMessageBoardRepository _repo;

        public RepliesController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Reply> Get(int topicId)
        {
            return _repo.GetRepliesByTopic(topicId);
        }

        public HttpResponseMessage post(int topicId, [FromBody]Reply newReply)
        {
            if (newReply.ReplyDateTime == default(DateTime))
            {
                newReply.ReplyDateTime = DateTime.UtcNow;
            }

            newReply.TopicId = topicId;

            try
            {
                if (_repo.AddReply(newReply) && _repo.Save())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, newReply);
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
