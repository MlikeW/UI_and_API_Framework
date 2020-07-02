using CommonUtilities.Methods.CustomAttributes;

namespace UI.Pages.Base.CommonParts
{
    public enum Menus
    {
        [XPath(".//*[contains(@class,'menu-item')]/*[contains(text(),'{0}')]")] 
        MenuButton,
        [XPath(".//*[contains(@class,'demo-frame')]//*[contains(text(),'{0}')]")]
        SubMenuButton
    }
}
