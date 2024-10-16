using Microsoft.AspNetCore.Components.Forms;

namespace BlazorCodeSnippets.Common.Utils
{
    public class CustomFieldClassProvider : FieldCssClassProvider
    {
        private string _validFieldClass;

        private string _invalidFieldClass;

        public CustomFieldClassProvider()
            : this("is-valid", "is-invalid")
        {
        }

        public CustomFieldClassProvider(string validFieldClass, string invalidFieldClass)
        {
            _validFieldClass = validFieldClass;
            _invalidFieldClass = invalidFieldClass;
        }

        public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
        {
            if (editContext == null)
            {
                throw new ArgumentNullException("editContext");
            }

            bool flag = !editContext.GetValidationMessages(fieldIdentifier).Any();
            if (editContext.IsModified(in fieldIdentifier))
            {
                if (!flag)
                {
                    return _invalidFieldClass;
                }

                return _validFieldClass;
            }

            if (!flag)
            {
                return _invalidFieldClass;
            }

            return string.Empty;
        }
    }
}
