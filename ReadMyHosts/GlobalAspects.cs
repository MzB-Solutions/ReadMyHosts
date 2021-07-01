using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;

// This file contains registration of aspects that are applied to several classes of this project.
//[assembly: Log(AttributeTargetTypeAttributes = MulticastAttributes.Public, AttributeTargetMemberAttributes = MulticastAttributes.Public)]
[assembly: Log(AttributePriority = 1, AttributeTargetMemberAttributes = MulticastAttributes.Private | MulticastAttributes.Protected | MulticastAttributes.Internal | MulticastAttributes.Public)]
[assembly: Log(AttributePriority = 2, AttributeExclude = true, AttributeTargetMembers = "get_*")]
