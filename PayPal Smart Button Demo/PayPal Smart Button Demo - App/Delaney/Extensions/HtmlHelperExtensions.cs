using System;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.AspNetCore.Mvc.ViewFeatures
{
    public static class HtmlHelperExtensions
    {
        #region Bootstrap Submit Button Helpers
        /// <summary>
        /// Bootstrap Submit Button Helper
        /// </summary>
        /// <param name="htmlHelper">The helper</param>
        /// <param name="buttonText">The text for the button</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input type='submit' with the appropriate properties set.</returns>
        public static HtmlString SubmitButton(
            this IHtmlHelper htmlHelper,
            string           buttonText,
            object           htmlAttributes = null)
        {
            return SubmitButton(
                htmlHelper, 
                buttonText, 
                null, 
                false, 
                null, 
                htmlAttributes);
        }

        /// <summary>
        /// Bootstrap Submit Button Helper
        /// </summary>
        /// <param name="htmlHelper">The helper</param>
        /// <param name="buttonText">The text for the button</param>
        /// <param name="id">The id for the button</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input type='submit' with the appropriate properties set.</returns>
        public static HtmlString SubmitButton(
            this IHtmlHelper htmlHelper,
            string           buttonText, string id,
            object           htmlAttributes = null)
        {
            return SubmitButton(
                htmlHelper, 
                buttonText, 
                id, 
                false, 
                null, 
                htmlAttributes);
        }

        /// <summary>
        /// Bootstrap Submit Button Helper
        /// </summary>
        /// <param name="htmlHelper">The helper</param>
        /// <param name="buttonText">The text for the button</param>
        /// <param name="id">The id for the button</param>
        /// <param name="isDisabled">Set to true if you want the button disabled</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input type='submit' with the appropriate properties set.</returns>
        public static HtmlString SubmitButton(
            this IHtmlHelper htmlHelper,
            string           buttonText,
            string           id,
            bool             isDisabled,
            object           htmlAttributes = null)
        {
            return SubmitButton(
                htmlHelper, 
                buttonText, 
                id, 
                isDisabled, 
                null, 
                htmlAttributes);
        }

        /// <summary>
        /// Bootstrap Submit Button Helper
        /// </summary>
        /// <param name="htmlHelper">The helper</param>
        /// <param name="buttonText">The text for the button</param>
        /// <param name="id">The id for the button</param>
        /// <param name="isDisabled">Set to true if you want the button disabled</param>
        /// <param name="btnClass">The bootstrap 'btn-' class to use for this button</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input type='submit' with the appropriate properties set.</returns>
        public static HtmlString SubmitButton(
            this IHtmlHelper htmlHelper,
            string           buttonText,
            string           id,
            bool             isDisabled,
            string           btnClass,
            object           htmlAttributes = null)
        {

            if (string.IsNullOrEmpty(id))
                id = buttonText;

            if (string.IsNullOrEmpty(btnClass))
                btnClass = "btn-primary";

            // Ensure ID is a valid identifier
            id = id.Replace(
                " ",
                "").Replace(
                    "-",
                    "_");

            string html = string.Empty;
            html = "<input type='submit' class='btn {3}{1}' title='{0}' value='{0}' id='{2}' {4} />";
            string disable = string.Empty;

            if (isDisabled)
                disable = " disabled";

            html = string.Format(
                html,
                buttonText,
                disable,
                id,
                btnClass,
                GetHtmlAttributes(htmlAttributes));

            html = html.Replace(
                "'",
                "\"");

            return new HtmlString(html);
        }
        #endregion

        #region Bootstrap/HTML 5 Check Box Helpers
        /// <summary>
        /// Bootstrap and HTML 5 Check Box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="text">The text to display next to this check box.</param>
        /// <returns>An HTML checkbox with the appropriate type set.</returns>
        public static HtmlString CheckBoxBootstrapFor<TModel, TValue>(
            this IHtmlHelper<TModel>         htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string                           id,
            string                           text,
            object                           htmlAttributes = null)
        {
            return CheckBoxBootstrapFor(
                htmlHelper,
                expression, 
                id, 
                text, 
                false, 
                false, 
                false, 
                htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Check Box in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this check box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="text">The text to display next to this check box.</param>
        /// <param name="isChecked">Whether or not to set the 'checked' attribute on this check box.</param>
        /// <param name="isAutoFocus">Whether or not to set the 'autofocus' attribute on this check box.</param>
        /// <param name="useInline">Whether or not to use 'checkbox-inline' for the Bootstrap class.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML checkbox with the appropriate type set.</returns>
        public static HtmlString CheckBoxBootstrapFor<TModel, TValue>(
            this IHtmlHelper<TModel>         htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string                           id,
            string                           text,
            bool                             isChecked,
            bool                             isAutoFocus,
            bool                             useInline = false,
            object                           htmlAttributes = null)
        {
            string htmlChecked = string.Empty;
            if (isChecked)
                htmlChecked = "checked='checked'";

            string htmlAutoFocus = string.Empty;
            if (isAutoFocus)
                htmlAutoFocus = "autofocus='autofocus'";

            // Build the CheckBox
            StringBuilder sb = new StringBuilder(512);
            if (useInline)
                sb.Append("<label class='checkbox-inline'>");
            else
            {
                sb.Append("<div class='checkbox'>");
                sb.Append("  <label>");
            }

            sb.AppendFormat(
                "    <input id='{0}' name='{0}' type='checkbox' value='true' {1} {2}/><input name='{0}' type='hidden' value='false' {3} />",
                id, 
                htmlChecked, 
                htmlAutoFocus,
                GetHtmlAttributes(htmlAttributes));

            sb.AppendFormat("    {0}", text);
            if (useInline)
                sb.Append("</label>");
            else
            {
                sb.Append("  </label>");
                sb.Append("</div>");
            }


            // Return an MVC HTML String
            return new HtmlString(sb.ToString());
        }
        #endregion

        #region Bootstrap/HTML 5 Check Box in a Button Helpers
        /// <summary>
        /// Bootstrap and HTML 5 Check Box in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this check box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="text">The text to display next to this check box.</param>
        /// <returns>An HTML checkbox with the appropriate type set.</returns>
        public static HtmlString CheckBoxButtonFor<TModel, TValue>(
            this IHtmlHelper<TModel>         htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string                           id,
            string                           text,
            object                           htmlAttributes = null)
        {
            return CheckBoxButtonFor(
                htmlHelper,
                expression,
                id,
                text,
                null,
                false,
                false,
                false,
                htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Check Box in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this check box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="text">The text to display next to this check box.</param>
        /// <param name="btnClass">The Bootstrap 'btn-' class to add to this check box.</param>
        /// <returns>An HTML checkbox with the appropriate type set.</returns>
        public static HtmlString CheckBoxButtonFor<TModel, TValue>(
            this IHtmlHelper<TModel>         htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string                           id,
            string                           text,
            string                           btnClass,
            object                           htmlAttributes = null)
        {
            return CheckBoxButtonFor(
                htmlHelper,
                expression, 
                id,
                text, 
                btnClass, 
                false, 
                false, 
                false, 
                htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Check Box in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this check box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="text">The text to display next to this check box.</param>
        /// <param name="btnClass">The Bootstrap 'btn-' class to add to this check box.</param>
        /// <param name="isChecked">Whether or not to set the 'checked' attribute on this check box.</param>
        /// <param name="isAutoFocus">Whether or not to set the 'autofocus' attribute on this check box.</param>
        /// <param name="useInline">Whether or not to use 'checkbox-inline' for the Bootstrap class.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML checkbox with the appropriate type set.</returns>
        public static HtmlString CheckBoxButtonFor<TModel, TValue>(
            this IHtmlHelper<TModel>         htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string                           id,
            string                           text,
            string                           btnClass,
            bool                             isChecked,
            bool                             isAutoFocus,
            bool                             useInline = false,
            object                           htmlAttributes = null)
        {
            string htmlAutoFocus = string.Empty;

            if (string.IsNullOrEmpty(btnClass))
                btnClass = "btn-default";

            string htmlChecked = string.Empty;
            if (isChecked)
                htmlChecked = "checked='checked'";

            if (isAutoFocus)
                htmlChecked = "autofocus='autofocus'";

            string chkClass = "checkbox";
            if (useInline)
                chkClass = "checkbox-inline";


            // Build the CheckBox
            StringBuilder sb = new StringBuilder(512);
            sb.AppendFormat("<div class='{0}'>", chkClass);
            sb.AppendFormat("  <label class='btn {0}'>", btnClass);
            sb.AppendFormat(
                "    <input id='{0}' name='{0}' type='checkbox' value='true' {1} {2}/><input name='{0}' type='hidden' value='false' {3} />",
                id, 
                htmlChecked, 
                htmlAutoFocus,
                GetHtmlAttributes(htmlAttributes));
            sb.AppendFormat("    {0}", text);
            sb.Append("  </label>");
            sb.Append("</div>");

            // Return an MVC HTML String
            return new HtmlString(sb.ToString());
        }
        #endregion

        #region Bootstrap/HTML 5 Radio Button
        /// <summary>
        /// Bootstrap and HTML 5 Radio Button.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="name">The 'name' attribute to set.</param>
        /// <param name="text">The text to display next to this radio button.</param>
        /// <param name="value">The 'value' attribute to set.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML radio button with the appropriate type set.</returns>
        public static HtmlString RadioButtonBootstrapFor<TModel, TValue>(
            this IHtmlHelper<TModel>         htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string                           id,
            string                           name,
            string                           text,
            string                           value,
            object                           htmlAttributes = null)
        {
            return RadioButtonBootstrapFor(
                htmlHelper,
                expression, 
                id, 
                name, 
                text,
                value, 
                false,
                false, 
                false, 
                htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Radio Button in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this radio button.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="name">The 'name' attribute to set.</param>
        /// <param name="text">The text to display next to this radio button.</param>
        /// <param name="value">The 'value' attribute to set.</param>
        /// <param name="isChecked">Whether or not to set the 'checked' attribute on this radio button.</param>
        /// <param name="isAutoFocus">Whether or not to set the 'autofocus' attribute on this radio button.</param>
        /// <param name="useInline">Whether or not to use 'radio-inline' for the Bootstrap class.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML radio button with the appropriate type set.</returns>
        public static HtmlString RadioButtonBootstrapFor<TModel, TValue>(
            this IHtmlHelper<TModel>         htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string                           id,
            string                           name,
            string                           text,
            string                           value,
            bool                             isChecked,
            bool                             isAutoFocus,
            bool                             useInline = false,
            object                           htmlAttributes = null)
        {
            string rdoClass = "radio";

            string htmlChecked = string.Empty;
            if (isChecked)
                htmlChecked = "checked='checked'";

            string htmlAutoFocus = string.Empty;
            if (isAutoFocus)
                htmlAutoFocus = "autofocus='autofocus'";

            if (useInline)
                rdoClass = "radio-inline";


            // Build the Radio Button
            StringBuilder sb = new StringBuilder(512);
            sb.AppendFormat("<div class='{0}'>", rdoClass);
            sb.Append("  <label>");
            sb.AppendFormat(
                "    <input id='{0}' name='{1}' type='radio' value='{2}' {3} {4} {5} />",
                id,
                name,
                value,
                htmlChecked,
                htmlAutoFocus,
                GetHtmlAttributes(htmlAttributes));
            sb.AppendFormat("    {0}", text);
            sb.Append("  </label>");
            sb.Append("</div>");

            // Return an MVC HTML String
            return new HtmlString(sb.ToString());
        }
        #endregion

        #region Bootstrap/HTML 5 Radio Button in a Button Helpers
        /// <summary>
        /// Bootstrap and HTML 5 Radio Button in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this radio button.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="name">The 'name' attribute to set.</param>
        /// <param name="text">The text to display next to this radio button.</param>
        /// <param name="value">The 'value' attribute to set.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML radio button with the appropriate type set.</returns>
        public static HtmlString RadioButtonInButtonFor<TModel, TValue>(
            this IHtmlHelper<TModel>         htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string                           id,
            string                           name,
            string                           text,
            string                           value,
            object                           htmlAttributes = null)
        {
            return RadioButtonInButtonFor(
                htmlHelper,
                expression, 
                id,
                name, 
                text, 
                value, 
                null, 
                false, 
                false, 
                false, 
                htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Radio Button in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this radio button.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="name">The 'name' attribute to set.</param>
        /// <param name="text">The text to display next to this radio button.</param>
        /// <param name="value">The 'value' attribute to set.</param>
        /// <param name="btnClass">The Bootstrap 'btn-' class to add to this check box.</param>
        /// <param name="isChecked">Whether or not to set the 'checked' attribute on this radio button.</param>
        /// <param name="isAutoFocus">Whether or not to set the 'autofocus' attribute on this radio button.</param>
        /// <param name="useInline">Whether or not to use 'radio-inline' for the Bootstrap class.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML radio button with the appropriate type set.</returns>
        public static HtmlString RadioButtonInButtonFor<TModel, TValue>(
            this IHtmlHelper<TModel>         htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string                           id,
            string                           name,
            string                           text,
            string                           value,
            string                           btnClass,
            bool                             isChecked,
            bool                             isAutoFocus,
            bool                             useInline      = false,
            object                           htmlAttributes = null)
        {
            StringBuilder sb = new StringBuilder(512);
            string htmlChecked = string.Empty;
            string htmlAutoFocus = string.Empty;
            string rdoClass = "radio";

            if (string.IsNullOrEmpty(btnClass))
                btnClass = "btn-default";

            if (isChecked)
                htmlChecked = "checked='checked'";

            if (isAutoFocus)
                htmlAutoFocus = "autofocus='autofocus'";

            if (useInline)
                rdoClass = "radio-inline";

            // Build the Radio Button
            sb.AppendFormat("<div class='{0}'>", rdoClass);
            sb.AppendFormat("  <label class='btn {0}'>", btnClass);
            sb.AppendFormat(
                "    <input id='{0}' name='{1}' type='radio' value='{2}' {3} {4} {5} />",
                id,
                name,
                value,
                htmlChecked,
                htmlAutoFocus,
                GetHtmlAttributes(htmlAttributes));
            sb.AppendFormat("    {0}", text);
            sb.Append("  </label>");
            sb.Append("</div>");

            // Return an MVC HTML String
            return new HtmlString(sb.ToString());
        }
        #endregion


        #region GetHtmlAttributes Method
        /// <summary>
        /// Break the HTML Attributes apart and put into key='value' pairs for adding to an HTML element.
        /// </summary>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>A string with the key='value' pairs</returns>
        private static string GetHtmlAttributes(object htmlAttributes)
        {
            string ret = string.Empty;

            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var item 
                    in attributes)
                {
                    ret += " " + item.Key + "=" + "'" + item.Value + "'";
                }
            }

            return ret;
        }
        #endregion
    }
}