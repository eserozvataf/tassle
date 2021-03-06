// --------------------------------------------------------------------------
// <copyright file="DefaultCliStartup.cs" company="-">
//   Copyright (c) 2008-2019 Eser Ozvataf (eser@ozvataf.com). All rights reserved.
//   Licensed under the Apache-2.0 license. See LICENSE file in the project root
//   for full license information.
//
//   Web: http://eser.ozvataf.com/ GitHub: http://github.com/eserozvataf
// </copyright>
// <author>Eser Ozvataf (eser@ozvataf.com)</author>
// --------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.Hosting {
    public class DefaultCliStartup : ITassleStartup {
        public virtual void ConfigureServiceProvider(HostBuilderContext hostingContext, IServiceCollection services) {
        }

        // public void Configure(ILogger<DefaultWebApiStartup> logger) {
        //     logger.LogWarning("cli test");
        // }
    }
}
