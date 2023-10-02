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
    /// Describes the ID format settings for your resources on a per-Region basis, for example,
    /// to view which resource types are enabled for longer IDs. This request only returns
    /// information about resource types whose ID formats can be modified; it does not return
    /// information about other resource types.
    /// 
    ///  
    /// <para>
    /// The following resource types support longer IDs: <code>bundle</code> | <code>conversion-task</code>
    /// | <code>customer-gateway</code> | <code>dhcp-options</code> | <code>elastic-ip-allocation</code>
    /// | <code>elastic-ip-association</code> | <code>export-task</code> | <code>flow-log</code>
    /// | <code>image</code> | <code>import-task</code> | <code>instance</code> | <code>internet-gateway</code>
    /// | <code>network-acl</code> | <code>network-acl-association</code> | <code>network-interface</code>
    /// | <code>network-interface-attachment</code> | <code>prefix-list</code> | <code>reservation</code>
    /// | <code>route-table</code> | <code>route-table-association</code> | <code>security-group</code>
    /// | <code>snapshot</code> | <code>subnet</code> | <code>subnet-cidr-block-association</code>
    /// | <code>volume</code> | <code>vpc</code> | <code>vpc-cidr-block-association</code>
    /// | <code>vpc-endpoint</code> | <code>vpc-peering-connection</code> | <code>vpn-connection</code>
    /// | <code>vpn-gateway</code>. 
    /// </para><para>
    /// These settings apply to the IAM user who makes the request; they do not apply to the
    /// entire Amazon Web Services account. By default, an IAM user defaults to the same settings
    /// as the root user, unless they explicitly override the settings by running the <a>ModifyIdFormat</a>
    /// command. Resources created with longer IDs are visible to all IAM users, regardless
    /// of these settings and provided that they have permission to use the relevant <code>Describe</code>
    /// command for the resource type.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2IdFormat")]
    [OutputType("Amazon.EC2.Model.IdFormat")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeIdFormat API operation.", Operation = new[] {"DescribeIdFormat"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeIdFormatResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IdFormat or Amazon.EC2.Model.DescribeIdFormatResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.IdFormat objects.",
        "The service call response (type Amazon.EC2.Model.DescribeIdFormatResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2IdFormatCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The type of resource: <code>bundle</code> | <code>conversion-task</code> | <code>customer-gateway</code>
        /// | <code>dhcp-options</code> | <code>elastic-ip-allocation</code> | <code>elastic-ip-association</code>
        /// | <code>export-task</code> | <code>flow-log</code> | <code>image</code> | <code>import-task</code>
        /// | <code>instance</code> | <code>internet-gateway</code> | <code>network-acl</code>
        /// | <code>network-acl-association</code> | <code>network-interface</code> | <code>network-interface-attachment</code>
        /// | <code>prefix-list</code> | <code>reservation</code> | <code>route-table</code> |
        /// <code>route-table-association</code> | <code>security-group</code> | <code>snapshot</code>
        /// | <code>subnet</code> | <code>subnet-cidr-block-association</code> | <code>volume</code>
        /// | <code>vpc</code> | <code>vpc-cidr-block-association</code> | <code>vpc-endpoint</code>
        /// | <code>vpc-peering-connection</code> | <code>vpn-connection</code> | <code>vpn-gateway</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Resource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Statuses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeIdFormatResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeIdFormatResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Statuses";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Resource parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Resource' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Resource' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeIdFormatResponse, GetEC2IdFormatCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Resource;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Resource = this.Resource;
            
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
            var request = new Amazon.EC2.Model.DescribeIdFormatRequest();
            
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
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
        
        private Amazon.EC2.Model.DescribeIdFormatResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeIdFormatRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeIdFormat");
            try
            {
                #if DESKTOP
                return client.DescribeIdFormat(request);
                #elif CORECLR
                return client.DescribeIdFormatAsync(request).GetAwaiter().GetResult();
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
            public System.String Resource { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeIdFormatResponse, GetEC2IdFormatCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Statuses;
        }
        
    }
}
