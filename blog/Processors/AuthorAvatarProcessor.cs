
using Our.Umbraco.Ditto;
using Umbraco.Core.Models;

namespace blog.Processors
{
    public class AuthorAvatarProcessor : DittoProcessorAttribute
    {
        /// <summary>
        /// Need to return a string point to user avatar path
        /// </summary>
        /// <returns></returns>
        public override object ProcessValue()
        {
            var content = Value as IPublishedContent;
            var creatorId = content.CreatorId;

            var creator = ApplicationContext.Services.UserService.GetUserById(creatorId);
            return creator?.Avatar;
        }
    }
}