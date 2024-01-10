/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Proton;
using Amazon.Proton.Model;

namespace Amazon.PowerShell.Cmdlets.PRO
{
    /// <summary>
    /// If no other minor versions of a service template exist, delete a major version of
    /// the service template if it's not the <c>Recommended</c> version. Delete the <c>Recommended</c>
    /// version of the service template if no other major versions or minor versions of the
    /// service template exist. A major version of a service template is a version that <i>isn't</i>
    /// backwards compatible.
    /// 
    ///  
    /// <para>
    /// Delete a minor version of a service template if it's not the <c>Recommended</c> version.
    /// Delete a <c>Recommended</c> minor version of the service template if no other minor
    /// versions of the service template exist. A minor version of a service template is a
    /// version that's backwards compatible.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "PROServiceTemplateVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Proton.Model.ServiceTemplateVersion")]
    [AWSCmdlet("Calls the AWS Proton DeleteServiceTemplateVersion API operation.", Operation = new[] {"DeleteServiceTemplateVersion"}, SelectReturnType = typeof(Amazon.Proton.Model.DeleteServiceTemplateVersionResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.ServiceTemplateVersion or Amazon.Proton.Model.DeleteServiceTemplateVersionResponse",
        "This cmdlet returns an Amazon.Proton.Model.ServiceTemplateVersion object.",
        "The service call response (type Amazon.Proton.Model.DeleteServiceTemplateVersionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemovePROServiceTemplateVersionCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MajorVersion
        /// <summary>
        /// <para>
        /// <para>The service template major version to delete.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MajorVersion { get; set; }
        #endregion
        
        #region Parameter MinorVersion
        /// <summary>
        /// <para>
        /// <para>The service template minor version to delete.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MinorVersion { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the service template.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceTemplateVersion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.DeleteServiceTemplateVersionResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.DeleteServiceTemplateVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceTemplateVersion";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-PROServiceTemplateVersion (DeleteServiceTemplateVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.DeleteServiceTemplateVersionResponse, RemovePROServiceTemplateVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MajorVersion = this.MajorVersion;
            #if MODULAR
            if (this.MajorVersion == null && ParameterWasBound(nameof(this.MajorVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter MajorVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinorVersion = this.MinorVersion;
            #if MODULAR
            if (this.MinorVersion == null && ParameterWasBound(nameof(this.MinorVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter MinorVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Proton.Model.DeleteServiceTemplateVersionRequest();
            
            if (cmdletContext.MajorVersion != null)
            {
                request.MajorVersion = cmdletContext.MajorVersion;
            }
            if (cmdletContext.MinorVersion != null)
            {
                request.MinorVersion = cmdletContext.MinorVersion;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Proton.Model.DeleteServiceTemplateVersionResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.DeleteServiceTemplateVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "DeleteServiceTemplateVersion");
            try
            {
                #if DESKTOP
                return client.DeleteServiceTemplateVersion(request);
                #elif CORECLR
                return client.DeleteServiceTemplateVersionAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String MajorVersion { get; set; }
            public System.String MinorVersion { get; set; }
            public System.String TemplateName { get; set; }
            public System.Func<Amazon.Proton.Model.DeleteServiceTemplateVersionResponse, RemovePROServiceTemplateVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceTemplateVersion;
        }
        
    }
}
