using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLabApiClient;
using GitLabApiClient.Models.Issues.Requests;
using GitLabApiClient.Models.MergeRequests.Requests;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var client = new GitLabClient("https://gitlab.com", "pYeZ6b5FFR9_nttV1xEx");

            //var client = new GitLabClient("https://gitlab.com");
            //await client.LoginAsync("libgit2sharp", "pYeZ6b5FFR9_nttV1xEx");
            //Use it:
            // create a new issue.
            //await client.Issues.CreateAsync(new CreateIssueRequest("projectId", "issue title"));

            var projects = await client.Projects.GetAsync(options => options.IsMemberOf = true);

            var projectNames = projects.Select(p => p.Name);

            // list issues for a project  with specified assignee and labels.
            var issues = await client.Issues.GetAsync("12098724", o =>
            {
                //o.AssigneeId = 100
            });

            // create a new merge request featureBranch -> master.
            await client.MergeRequests.CreateAsync(new CreateMergeRequest("projectId", "featureBranch", "master", "Merge request title")
            {
                Labels = new[] { "bugfix" },
                Description = "Implement feature"
            });
        }
    }
}
