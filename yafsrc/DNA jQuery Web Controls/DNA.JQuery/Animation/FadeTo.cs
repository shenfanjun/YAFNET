﻿///  Copyright (c) 2009 Ray Liang (http://www.dotnetage.com)
///  Dual licensed under the MIT and GPL licenses:
///  http://www.opensource.org/licenses/mit-license.php
///  http://www.gnu.org/licenses/gpl.html
using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.Drawing.Design;
using System.Collections.Generic;

namespace DNA.UI.JQuery
{

    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [DefaultProperty("Opacity")]
    public class FadeTo : Animate
    {
        private float opacity = 1;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override EasingMethods Easing
        {
            get
            {
                return base.Easing;
            }
            set
            {
                base.Easing = value;
            }
        }

        /// <summary>
        /// Gets/Sets the opacity of the fadeTo animation
        /// </summary>
        [Category("")]
        [Description("Gets/Sets the opacity of the fadeTo animation")]
        public float Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }

        public override string GetAnimationScripts()
        {
            StringBuilder scripts = new StringBuilder();
            scripts.Append(".fadeTo(");
            scripts.Append(GetSpeed());
            scripts.Append("," + opacity.ToString());
            if (!string.IsNullOrEmpty(OnClientCallBack))
                scripts.Append("," + ClientScriptManager.FormatFunctionString(OnClientCallBack));

            scripts.Append(")");

            foreach (Animate ani in Animates)
                scripts.Append(ani.GetAnimationScripts());

            return scripts.ToString();
        }
    }
}