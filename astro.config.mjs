import { defineConfig } from "astro/config";
import starlight from "@astrojs/starlight";
import react from "@astrojs/react";
import starlightLinksValidator from "starlight-links-validator";
import sitemap from "@astrojs/sitemap";
import remarkMath from "remark-math";
import rehypeMathjax from "rehype-mathjax";
import starlightBlog from "starlight-blog";
import starlightDocSearch from "@astrojs/starlight-docsearch";
import remarkHeadingID from "remark-heading-id";
import { loadEnv } from "vite";

// ✅ Correct env loading
const env = loadEnv(process.env.NODE_ENV ?? "development", process.cwd(), "");

// Support both naming styles
const DOCSEARCH_API_ID =
  env.PUBLIC_DOCSEARCH_API_ID || env.DOCSEARCH_API_ID;

const DOCSEARCH_API_SEARCH_KEY =
  env.PUBLIC_DOCSEARCH_API_SEARCH_KEY || env.DOCSEARCH_API_SEARCH_KEY;

const DOCSEARCH_INDEX_NAME =
  env.PUBLIC_DOCSEARCH_INDEX_NAME || env.DOCSEARCH_INDEX_NAME;

// Only enable docsearch if all values exist
const docsearchEnabled =
  DOCSEARCH_API_ID &&
  DOCSEARCH_API_SEARCH_KEY &&
  DOCSEARCH_INDEX_NAME;

if (!docsearchEnabled) {
  console.warn(
    "⚠️ DocSearch disabled: missing environment variables. Search will not work."
  );
}

// https://astro.build/config
export default defineConfig({
  site: "https://splashkit.io/",

  integrations: [
    starlight({
      title: "SplashKit",
      description:
        "SplashKit is a cross-platform game engine for C, C++ and Objective-C. It provides a simple API for 2D game development.",

      plugins: [
        starlightBlog({
          title: "Announcements",
          recentPostCount: 5,
          prevNextLinksOrder: "chronological",
        }),

        starlightLinksValidator({
          errorOnRelativeLinks: true,
        }),

        // ✅ Only enable DocSearch if env is valid
        ...(docsearchEnabled
          ? [
              starlightDocSearch({
                appId: DOCSEARCH_API_ID,
                apiKey: DOCSEARCH_API_SEARCH_KEY,
                indexName: DOCSEARCH_INDEX_NAME,
              }),
            ]
          : []),
      ],

      expressiveCode: {
        styleOverrides: { borderRadius: "0.5rem" },
        useDarkModeMediaQuery: true,
      },

      customCss: [
        "/src/styles/custom.css",
        "/src/styles/background.css",
        "/src/styles/cards.css",
      ],

      social: [
        {
          icon: "github",
          label: "GitHub",
          href: "https://github.com/splashkit",
        },
        {
          icon: "youtube",
          label: "YouTube",
          href: "https://www.youtube.com/@splashkit7674",
        },
      ],

      favicon: "/images/favicon.svg",

      logo: {
        src: "./src/assets/favicon.svg",
      },

      sidebar: [
        {
          label: "Installation",
          collapsed: false,
          items: [
            { label: "Installation Overview", link: "installation/" },
            {
              label: "Windows",
              collapsed: true,
              items: [
                {
                  label: "MSYS2",
                  autogenerate: {
                    directory: "installation/Windows (MSYS2)",
                  },
                  collapsed: false,
                },
                {
                  label: "WSL",
                  autogenerate: {
                    directory: "installation/Windows (WSL)",
                  },
                  collapsed: false,
                },
              ],
            },
            {
              label: "MacOS",
              autogenerate: { directory: "installation/MacOS" },
              collapsed: true,
            },
            {
              label: "Linux",
              autogenerate: { directory: "installation/Linux" },
              collapsed: true,
            },
            {
              label: "Virtual Machine",
              autogenerate: {
                directory: "installation/Virtual Machine",
              },
              collapsed: true,
            },
          ],
        },

        {
          label: "Troubleshooting",
          collapsed: true,
          items: [
            { label: "Troubleshooting Overview", link: "troubleshoot/" },
            {
              label: "Windows",
              collapsed: true,
              items: [
                {
                  label: "MSYS2",
                  autogenerate: { directory: "troubleshoot/Windows (MSYS2)" },
                  collapsed: false,
                },
                {
                  label: "WSL",
                  autogenerate: { directory: "troubleshoot/Windows (WSL)" },
                  collapsed: false,
                },
              ],
            },
            {
              label: "MacOS",
              autogenerate: { directory: "troubleshoot/MacOS" },
              collapsed: true,
            },
            {
              label: "Linux",
              autogenerate: { directory: "troubleshoot/Linux" },
              collapsed: true,
            },
          ],
        },

        {
          label: "API Documentation",
          autogenerate: { directory: "api", collapsed: false },
        },

        {
          label: "Tutorials and Guides",
          collapsed: false,
          items: [
            { label: "Overview", link: "guides/" },
            {
              label: "Getting Started",
              collapsed: false,
              items: [
                {
                  label: "Drawing with Procedures",
                  link: "guides/graphics/drawing-using-procedures",
                },
                {
                  label: "Understanding Double Buffering",
                  link: "guides/graphics/double-buffering",
                },
                {
                  label: "Graphical User Inputs",
                  link: "guides/input/user-inputs-in-graphical-applications",
                },
                {
                  label: "Loading Resources with Bundles",
                  link: "guides/resources/loading-resources-with-bundles",
                },
                {
                  label: "Getting Started With Audio",
                  link: "guides/audio/getting-started-with-audio",
                },
                {
                  label: "Using Animations",
                  link: "guides/animations/using-animations",
                },
                {
                  label: "SplashKit Camera",
                  link: "guides/input/using-splashkit-camera",
                },
                {
                  label: "Useful Utilities",
                  link: "guides/utilities/useful-utilities",
                },
                {
                  label: "Using JSON in SplashKit",
                  link: "guides/json/getting-started-with-json",
                },
                {
                  label: "SplashKit Colors",
                  link: "guides/color/splashkit-colors",
                },
              ],
            },

            {
              label: "Raspberry GPIO",
              autogenerate: { directory: "guides/raspberry-gpio" },
              collapsed: true,
            },

            {
              label: "Physics",
              autogenerate: { directory: "guides/physics" },
              collapsed: true,
            },

            {
              label: "Interface",
              autogenerate: { directory: "guides/interface" },
              collapsed: true,
            },

            {
              label: "Networking",
              autogenerate: { directory: "guides/networking" },
              collapsed: true,
            },
          ],
        },
      ],
    }),

    react(),
    sitemap(),
  ],

  server: {
    host: true,
    port: 4321,
  },

  markdown: {
    remarkPlugins: [remarkMath, remarkHeadingID],
    rehypePlugins: [rehypeMathjax],
  },
});