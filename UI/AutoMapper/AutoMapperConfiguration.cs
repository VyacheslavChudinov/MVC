using AutoMapper;

namespace ListingsManager.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<PostProfile>();
                x.AddProfile<UserProfile>();
            });
        }

    }
}
