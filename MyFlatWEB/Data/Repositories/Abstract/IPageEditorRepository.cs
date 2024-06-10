using MyFlatWEB.Areas.Management.Models.EditPages;
using MyFlatWEB.Models.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Data.Repositories.Abstract
{
    public interface IPageEditorRepository
    {
        HomePagePlaceholderModel GetHomePagePlaceholder();

        Task<bool> ChangeNameLinkTopMenu(TopMenuLinkNameModel model);

        Task<bool> AddRandomPhrase(RandomPhraseModel model);

        Task<bool> ChangeRandomPhrase(RandomPhraseModel model);

        Task<bool> DeleteRandomPhrase(int id);

        Task<bool> ChangeLeftCentralAreaText(HomePagePlaceholderModel model);

        Task<bool> ChangeMainImage(HomePagePlaceholderModel model);

        Task<bool> ChangeBottomAreaHeader(HomePagePlaceholderModel model);

        Task<bool> ChangeBottomAreaContent(HomePagePlaceholderModel model);

        List<ProjectModel> GetProjectsFromDB();

        Task<bool> AddProjectToDB(ProjectModel model);

        ProjectModel GetProjectById(int id);

        Task<bool> ChangeProject(ProjectModel model);

        Task<bool> DeleteProjectById(int id);

        List<ServiceModel> GetServicesFromDB();

        Task<bool> AddServiceToDB(ServiceModel model);

        ServiceModel GetServiceById(int id);

        Task<bool> ChangeService(ServiceModel model);

        Task<bool> DeleteServiceById(int id);

        List<PostModel> GetPostsFromDB();

        Task<bool> AddPostToDB(PostModel model);

        PostModel GetPostById(int id);

        Task<bool> ChangePost(PostModel model);

        Task<bool> DeletePostById(int id);

        ContactModel GetContactsFromDB();

        List<SocialModel> GetSocialLinksFromDB();

        Task<bool> ChangeContacts(ContactModel model);
    }
}
