using Sakura.AspNet.Mvc.PagedList;

namespace KEnergy.WebUI.Helpers.UI
{
    public class AppPagerOptions
    {
        public static PagerOptions Configurate()
        {
            var pagerOptions = new PagerOptions
            {
                ExpandPageLinksForCurrentPage = 2, // Will display more 2 pager buttons before and after current page.
                PageLinksForEndings = 2, // Will display 2 pager buttons for first and last pages.
                Layout = PagedListPagerLayouts.Default,
                // Layout controls which elements will be displayed in the pager. For more information, please read the documentation.

                // Options for all pager items.
                Items = new PagerItemOptions
                {
                    TextFormat = "{0}",
                    // The format for the pager button text, here means the content is just the actual page number. This property is used with string.Format method.
                    LinkParameterName = "page",
                    // This property measn the generated pager button url will append the "page={pageNumber}" to the current URL.
                },

                // Configure for "go to next" button
                NextButton = new SpecialPagerItemOptions
                {
                    Text = "Next",
                    InactiveBehavior = SpecialPagerItemInactiveBehavior.Disable,
                    // When there is no next page, disable this button
                    LinkParameterName = "page"
                },

                // Configure for "go to previous" button
                PreviousButton = new SpecialPagerItemOptions
                {
                    Text = "Previous",
                    InactiveBehavior = SpecialPagerItemInactiveBehavior.Disable,
                    // When there is no next page, disable this button
                    LinkParameterName = "page"
                },

                // Configure for "go to first page" button
                FirstButton = new FirstAndLastPagerItemOptions
                {
                    Text = "First",
                    ActiveMode = FirstAndLastPagerItemActiveMode.Always,
                    InactiveBehavior = SpecialPagerItemInactiveBehavior.Disable,
                    LinkParameterName = "page",
                },

                // Configure for "go to last page" button
                LastButton = new FirstAndLastPagerItemOptions
                {
                    Text = "Last",
                    ActiveMode = FirstAndLastPagerItemActiveMode.Always,
                    InactiveBehavior = SpecialPagerItemInactiveBehavior.Disable,
                    LinkParameterName = "page",
                },

                // Configure for omitted buttons (placeholder button when there's too many pages)
                Omitted = new PagerItemOptions
                {
                    Text = "...",
                    Link = string.Empty // disable link
                },
            };
            return new PagerOptions();
        }
    }
}