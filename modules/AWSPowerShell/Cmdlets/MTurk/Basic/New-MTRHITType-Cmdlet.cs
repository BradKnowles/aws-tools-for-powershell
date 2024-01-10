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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <c>CreateHITType</c> operation creates a new HIT type. This operation allows
    /// you to define a standard set of HIT properties to use when creating HITs. If you register
    /// a HIT type with values that match an existing HIT type, the HIT type ID of the existing
    /// type will be returned.
    /// </summary>
    [Cmdlet("New", "MTRHITType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon MTurk Service CreateHITType API operation.", Operation = new[] {"CreateHITType"}, SelectReturnType = typeof(Amazon.MTurk.Model.CreateHITTypeResponse))]
    [AWSCmdletOutput("System.String or Amazon.MTurk.Model.CreateHITTypeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MTurk.Model.CreateHITTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMTRHITTypeCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssignmentDurationInSecond
        /// <summary>
        /// <para>
        /// <para> The amount of time, in seconds, that a Worker has to complete the HIT after accepting
        /// it. If a Worker does not complete the assignment within the specified duration, the
        /// assignment is considered abandoned. If the HIT is still active (that is, its lifetime
        /// has not elapsed), the assignment becomes available for other users to find and accept.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AssignmentDurationInSeconds")]
        public System.Int64? AssignmentDurationInSecond { get; set; }
        #endregion
        
        #region Parameter AutoApprovalDelayInSecond
        /// <summary>
        /// <para>
        /// <para> The number of seconds after an assignment for the HIT has been submitted, after which
        /// the assignment is considered Approved automatically unless the Requester explicitly
        /// rejects it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoApprovalDelayInSeconds")]
        public System.Int64? AutoApprovalDelayInSecond { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> A general description of the HIT. A description includes detailed information about
        /// the kind of task the HIT contains. On the Amazon Mechanical Turk web site, the HIT
        /// description appears in the expanded view of search results, and in the HIT and assignment
        /// screens. A good description gives the user enough information to evaluate the HIT
        /// before accepting it. </para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Keyword
        /// <summary>
        /// <para>
        /// <para> One or more words or phrases that describe the HIT, separated by commas. These words
        /// are used in searches to find HITs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Keywords")]
        public System.String Keyword { get; set; }
        #endregion
        
        #region Parameter QualificationRequirement
        /// <summary>
        /// <para>
        /// <para> Conditions that a Worker's Qualifications must meet in order to accept the HIT. A
        /// HIT can have between zero and ten Qualification requirements. All requirements must
        /// be met in order for a Worker to accept the HIT. Additionally, other actions can be
        /// restricted using the <c>ActionsGuarded</c> field on each <c>QualificationRequirement</c>
        /// structure. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QualificationRequirements")]
        public Amazon.MTurk.Model.QualificationRequirement[] QualificationRequirement { get; set; }
        #endregion
        
        #region Parameter Reward
        /// <summary>
        /// <para>
        /// <para> The amount of money the Requester will pay a Worker for successfully completing the
        /// HIT. </para>
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
        public System.String Reward { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para> The title of the HIT. A title should be short and descriptive about the kind of task
        /// the HIT contains. On the Amazon Mechanical Turk web site, the HIT title appears in
        /// search results, and everywhere the HIT is mentioned. </para>
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
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HITTypeId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MTurk.Model.CreateHITTypeResponse).
        /// Specifying the name of a property of type Amazon.MTurk.Model.CreateHITTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HITTypeId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Title parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Title' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Title' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Title), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MTRHITType (CreateHITType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MTurk.Model.CreateHITTypeResponse, NewMTRHITTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Title;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssignmentDurationInSecond = this.AssignmentDurationInSecond;
            #if MODULAR
            if (this.AssignmentDurationInSecond == null && ParameterWasBound(nameof(this.AssignmentDurationInSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter AssignmentDurationInSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoApprovalDelayInSecond = this.AutoApprovalDelayInSecond;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Keyword = this.Keyword;
            if (this.QualificationRequirement != null)
            {
                context.QualificationRequirement = new List<Amazon.MTurk.Model.QualificationRequirement>(this.QualificationRequirement);
            }
            context.Reward = this.Reward;
            #if MODULAR
            if (this.Reward == null && ParameterWasBound(nameof(this.Reward)))
            {
                WriteWarning("You are passing $null as a value for parameter Reward which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Title = this.Title;
            #if MODULAR
            if (this.Title == null && ParameterWasBound(nameof(this.Title)))
            {
                WriteWarning("You are passing $null as a value for parameter Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MTurk.Model.CreateHITTypeRequest();
            
            if (cmdletContext.AssignmentDurationInSecond != null)
            {
                request.AssignmentDurationInSeconds = cmdletContext.AssignmentDurationInSecond.Value;
            }
            if (cmdletContext.AutoApprovalDelayInSecond != null)
            {
                request.AutoApprovalDelayInSeconds = cmdletContext.AutoApprovalDelayInSecond.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Keyword != null)
            {
                request.Keywords = cmdletContext.Keyword;
            }
            if (cmdletContext.QualificationRequirement != null)
            {
                request.QualificationRequirements = cmdletContext.QualificationRequirement;
            }
            if (cmdletContext.Reward != null)
            {
                request.Reward = cmdletContext.Reward;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.MTurk.Model.CreateHITTypeResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.CreateHITTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "CreateHITType");
            try
            {
                #if DESKTOP
                return client.CreateHITType(request);
                #elif CORECLR
                return client.CreateHITTypeAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? AssignmentDurationInSecond { get; set; }
            public System.Int64? AutoApprovalDelayInSecond { get; set; }
            public System.String Description { get; set; }
            public System.String Keyword { get; set; }
            public List<Amazon.MTurk.Model.QualificationRequirement> QualificationRequirement { get; set; }
            public System.String Reward { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.MTurk.Model.CreateHITTypeResponse, NewMTRHITTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HITTypeId;
        }
        
    }
}
