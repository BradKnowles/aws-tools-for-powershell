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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Returns the estimated number of decision tasks in the specified task list. The count
    /// returned is an approximation and isn't guaranteed to be exact. If you specify a task
    /// list that no decision task was ever scheduled in then <c>0</c> is returned.
    /// 
    ///  
    /// <para><b>Access Control</b></para><para>
    /// You can use IAM policies to control this action's access to Amazon SWF resources as
    /// follows:
    /// </para><ul><li><para>
    /// Use a <c>Resource</c> element with the domain name to limit the action to only specified
    /// domains.
    /// </para></li><li><para>
    /// Use an <c>Action</c> element to allow or deny permission to call this action.
    /// </para></li><li><para>
    /// Constrain the <c>taskList.name</c> parameter by using a <c>Condition</c> element with
    /// the <c>swf:taskList.name</c> key to allow the action to access only certain task lists.
    /// </para></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <c>cause</c> parameter is set to <c>OPERATION_NOT_PERMITTED</c>. For details
    /// and example IAM policies, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SWFPendingDecisionTaskCount")]
    [OutputType("Amazon.SimpleWorkflow.Model.PendingTaskCount")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service (SWF) CountPendingDecisionTasks API operation.", Operation = new[] {"CountPendingDecisionTasks"}, SelectReturnType = typeof(Amazon.SimpleWorkflow.Model.CountPendingDecisionTasksResponse))]
    [AWSCmdletOutput("Amazon.SimpleWorkflow.Model.PendingTaskCount or Amazon.SimpleWorkflow.Model.CountPendingDecisionTasksResponse",
        "This cmdlet returns an Amazon.SimpleWorkflow.Model.PendingTaskCount object.",
        "The service call response (type Amazon.SimpleWorkflow.Model.CountPendingDecisionTasksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSWFPendingDecisionTaskCountCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain that contains the task list.</para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter TaskList_Name
        /// <summary>
        /// <para>
        /// <para>The name of the task list.</para>
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
        public System.String TaskList_Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PendingTaskCount'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleWorkflow.Model.CountPendingDecisionTasksResponse).
        /// Specifying the name of a property of type Amazon.SimpleWorkflow.Model.CountPendingDecisionTasksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PendingTaskCount";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TaskList_Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TaskList_Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TaskList_Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleWorkflow.Model.CountPendingDecisionTasksResponse, GetSWFPendingDecisionTaskCountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TaskList_Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskList_Name = this.TaskList_Name;
            #if MODULAR
            if (this.TaskList_Name == null && ParameterWasBound(nameof(this.TaskList_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskList_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleWorkflow.Model.CountPendingDecisionTasksRequest();
            
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate TaskList
            var requestTaskListIsNull = true;
            request.TaskList = new Amazon.SimpleWorkflow.Model.TaskList();
            System.String requestTaskList_taskList_Name = null;
            if (cmdletContext.TaskList_Name != null)
            {
                requestTaskList_taskList_Name = cmdletContext.TaskList_Name;
            }
            if (requestTaskList_taskList_Name != null)
            {
                request.TaskList.Name = requestTaskList_taskList_Name;
                requestTaskListIsNull = false;
            }
             // determine if request.TaskList should be set to null
            if (requestTaskListIsNull)
            {
                request.TaskList = null;
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
        
        private Amazon.SimpleWorkflow.Model.CountPendingDecisionTasksResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.CountPendingDecisionTasksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service (SWF)", "CountPendingDecisionTasks");
            try
            {
                #if DESKTOP
                return client.CountPendingDecisionTasks(request);
                #elif CORECLR
                return client.CountPendingDecisionTasksAsync(request).GetAwaiter().GetResult();
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
            public System.String Domain { get; set; }
            public System.String TaskList_Name { get; set; }
            public System.Func<Amazon.SimpleWorkflow.Model.CountPendingDecisionTasksResponse, GetSWFPendingDecisionTaskCountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PendingTaskCount;
        }
        
    }
}
