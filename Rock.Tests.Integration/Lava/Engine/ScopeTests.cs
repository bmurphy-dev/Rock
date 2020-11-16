﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rock.Tests.Integration.Lava
{
    /// <summary>
    /// Test the scoping of variables in a Lava context using various container configurations
    /// </summary>
    [TestClass]
    public class ScopeTests : LavaIntegrationTestBase
    {
        // TODO: This is the observed behavior, but is it correct?
        [TestMethod]
        public void Scope_LocalVariableWithSameNameAsContainerVariable_ContainerVariableIsReturned()
        {
            var input = @"
{% execute type:'class' %}
    using Rock;
    using Rock.Data;
    using Rock.Model;
    
    public class MyScript 
    {
        public string Execute() {
            using(RockContext rockContext = new RockContext()){
                var person = new PersonService(rockContext).Get({{ CurrentPerson | Property: 'Id' }});
                
                return person.FullName;
            }
        }
    }
{% endexecute %}
";
            var expectedOutput = @"Admin Admin"; // NOT 'Ted Decker'

            var context = _helper.LavaEngine.NewContext();

            context.SetEnabledCommands( "execute" );

            context.SetMergeFieldValue( "CurrentPerson", _helper.GetTestPersonTedDecker() );

            _helper.AssertTemplateOutput( expectedOutput, input, context );
        }

        [TestMethod]
        public void Scope_WithInnerVariable_DoesNotModifyOuterVariable()
        {
            var input = @"
{% assign color = 'blue' %}
Color 1: {{ color }}

{% cache key:'fav-color' duration:'1200' %}
    Color 2: {{ color }}
    {% assign color = 'red' %}
    Color 3: {{color }}
{% endcache %}

Color 4: {{ color }}
";

            var expectedOutput = @"
Color 1: blue
Color 2: blue
Color 3: red
Color 4: blue
";

            var context = _helper.LavaEngine.NewContext();

            context.SetEnabledCommands( "Cache" );

            _helper.AssertTemplateOutput( expectedOutput, input, context, ignoreWhiteSpace: true );
        }

    }
}
