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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the specified attribute of the specified AMI. You can specify only one attribute
    /// at a time.
    /// 
    ///  
    /// <para>
    /// To specify the attribute, you can use the <c>Attribute</c> parameter, or one of the
    /// following parameters: <c>Description</c>, <c>ImdsSupport</c>, or <c>LaunchPermission</c>.
    /// </para><para>
    /// Images with an Amazon Web Services Marketplace product code cannot be made public.
    /// </para><para>
    /// To enable the SriovNetSupport enhanced networking attribute of an image, enable SriovNetSupport
    /// on an instance and create an AMI from the instance.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2ImageAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyImageAttribute API operation.", Operation = new[] {"ModifyImageAttribute"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyImageAttributeResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ModifyImageAttributeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ModifyImageAttributeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2ImageAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LaunchPermission_Add
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID, organization ARN, or OU ARN to add to the list
        /// of launch permissions for the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EC2.Model.LaunchPermission[] LaunchPermission_Add { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>The name of the attribute to modify.</para><para>Valid values: <c>description</c> | <c>imdsSupport</c> | <c>launchPermission</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Attribute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the AMI.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ImageId { get; set; }
        #endregion
        
        #region Parameter ImdsSupport
        /// <summary>
        /// <para>
        /// <para>Set to <c>v2.0</c> to indicate that IMDSv2 is specified in the AMI. Instances launched
        /// from this AMI will have <c>HttpTokens</c> automatically set to <c>required</c> so
        /// that, by default, the instance requires that IMDSv2 is used when requesting instance
        /// metadata. In addition, <c>HttpPutResponseHopLimit</c> is set to <c>2</c>. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/configuring-IMDS-new-instances.html#configure-IMDS-new-instances-ami-configuration">Configure
        /// the AMI</a> in the <i>Amazon EC2 User Guide</i>.</para><important><para>Do not use this parameter unless your AMI software supports IMDSv2. After you set
        /// the value to <c>v2.0</c>, you can't undo it. The only way to “reset” your AMI is to
        /// create a new AMI from the underlying snapshot.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImdsSupport { get; set; }
        #endregion
        
        #region Parameter OperationType
        /// <summary>
        /// <para>
        /// <para>The operation type. This parameter can be used only when the <c>Attribute</c> parameter
        /// is <c>launchPermission</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.OperationType")]
        public Amazon.EC2.OperationType OperationType { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an organizational unit (OU). This parameter can
        /// be used only when the <c>Attribute</c> parameter is <c>launchPermission</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationalUnitArns")]
        public System.String[] OrganizationalUnitArn { get; set; }
        #endregion
        
        #region Parameter OrganizationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an organization. This parameter can be used only
        /// when the <c>Attribute</c> parameter is <c>launchPermission</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationArns")]
        public System.String[] OrganizationArn { get; set; }
        #endregion
        
        #region Parameter ProductCode
        /// <summary>
        /// <para>
        /// <para>Not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProductCodes")]
        public System.String[] ProductCode { get; set; }
        #endregion
        
        #region Parameter LaunchPermission_Remove
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID, organization ARN, or OU ARN to remove from the
        /// list of launch permissions for the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EC2.Model.LaunchPermission[] LaunchPermission_Remove { get; set; }
        #endregion
        
        #region Parameter UserGroup
        /// <summary>
        /// <para>
        /// <para>The user groups. This parameter can be used only when the <c>Attribute</c> parameter
        /// is <c>launchPermission</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserGroups")]
        public System.String[] UserGroup { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account IDs. This parameter can be used only when the <c>Attribute</c>
        /// parameter is <c>launchPermission</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserIds")]
        public System.String[] UserId { get; set; }
        #endregion
        
        #region Parameter Value
        /// <summary>
        /// <para>
        /// <para>The value of the attribute being modified. This parameter can be used only when the
        /// <c>Attribute</c> parameter is <c>description</c> or <c>imdsSupport</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyImageAttributeResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ImageId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ImageId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ImageId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2ImageAttribute (ModifyImageAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyImageAttributeResponse, EditEC2ImageAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ImageId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Attribute = this.Attribute;
            context.Description = this.Description;
            context.ImageId = this.ImageId;
            #if MODULAR
            if (this.ImageId == null && ParameterWasBound(nameof(this.ImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImdsSupport = this.ImdsSupport;
            if (this.LaunchPermission_Add != null)
            {
                context.LaunchPermission_Add = new List<Amazon.EC2.Model.LaunchPermission>(this.LaunchPermission_Add);
            }
            if (this.LaunchPermission_Remove != null)
            {
                context.LaunchPermission_Remove = new List<Amazon.EC2.Model.LaunchPermission>(this.LaunchPermission_Remove);
            }
            context.OperationType = this.OperationType;
            if (this.OrganizationalUnitArn != null)
            {
                context.OrganizationalUnitArn = new List<System.String>(this.OrganizationalUnitArn);
            }
            if (this.OrganizationArn != null)
            {
                context.OrganizationArn = new List<System.String>(this.OrganizationArn);
            }
            if (this.ProductCode != null)
            {
                context.ProductCode = new List<System.String>(this.ProductCode);
            }
            if (this.UserGroup != null)
            {
                context.UserGroup = new List<System.String>(this.UserGroup);
            }
            if (this.UserId != null)
            {
                context.UserId = new List<System.String>(this.UserId);
            }
            context.Value = this.Value;
            
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
            var request = new Amazon.EC2.Model.ModifyImageAttributeRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attribute = cmdletContext.Attribute;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
            }
            if (cmdletContext.ImdsSupport != null)
            {
                request.ImdsSupport = cmdletContext.ImdsSupport;
            }
            
             // populate LaunchPermission
            var requestLaunchPermissionIsNull = true;
            request.LaunchPermission = new Amazon.EC2.Model.LaunchPermissionModifications();
            List<Amazon.EC2.Model.LaunchPermission> requestLaunchPermission_launchPermission_Add = null;
            if (cmdletContext.LaunchPermission_Add != null)
            {
                requestLaunchPermission_launchPermission_Add = cmdletContext.LaunchPermission_Add;
            }
            if (requestLaunchPermission_launchPermission_Add != null)
            {
                request.LaunchPermission.Add = requestLaunchPermission_launchPermission_Add;
                requestLaunchPermissionIsNull = false;
            }
            List<Amazon.EC2.Model.LaunchPermission> requestLaunchPermission_launchPermission_Remove = null;
            if (cmdletContext.LaunchPermission_Remove != null)
            {
                requestLaunchPermission_launchPermission_Remove = cmdletContext.LaunchPermission_Remove;
            }
            if (requestLaunchPermission_launchPermission_Remove != null)
            {
                request.LaunchPermission.Remove = requestLaunchPermission_launchPermission_Remove;
                requestLaunchPermissionIsNull = false;
            }
             // determine if request.LaunchPermission should be set to null
            if (requestLaunchPermissionIsNull)
            {
                request.LaunchPermission = null;
            }
            if (cmdletContext.OperationType != null)
            {
                request.OperationType = cmdletContext.OperationType;
            }
            if (cmdletContext.OrganizationalUnitArn != null)
            {
                request.OrganizationalUnitArns = cmdletContext.OrganizationalUnitArn;
            }
            if (cmdletContext.OrganizationArn != null)
            {
                request.OrganizationArns = cmdletContext.OrganizationArn;
            }
            if (cmdletContext.ProductCode != null)
            {
                request.ProductCodes = cmdletContext.ProductCode;
            }
            if (cmdletContext.UserGroup != null)
            {
                request.UserGroups = cmdletContext.UserGroup;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserIds = cmdletContext.UserId;
            }
            if (cmdletContext.Value != null)
            {
                request.Value = cmdletContext.Value;
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
        
        private Amazon.EC2.Model.ModifyImageAttributeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyImageAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyImageAttribute");
            try
            {
                #if DESKTOP
                return client.ModifyImageAttribute(request);
                #elif CORECLR
                return client.ModifyImageAttributeAsync(request).GetAwaiter().GetResult();
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
            public System.String Attribute { get; set; }
            public System.String Description { get; set; }
            public System.String ImageId { get; set; }
            public System.String ImdsSupport { get; set; }
            public List<Amazon.EC2.Model.LaunchPermission> LaunchPermission_Add { get; set; }
            public List<Amazon.EC2.Model.LaunchPermission> LaunchPermission_Remove { get; set; }
            public Amazon.EC2.OperationType OperationType { get; set; }
            public List<System.String> OrganizationalUnitArn { get; set; }
            public List<System.String> OrganizationArn { get; set; }
            public List<System.String> ProductCode { get; set; }
            public List<System.String> UserGroup { get; set; }
            public List<System.String> UserId { get; set; }
            public System.String Value { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyImageAttributeResponse, EditEC2ImageAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
