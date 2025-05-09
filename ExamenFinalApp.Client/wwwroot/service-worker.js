const CACHE_NAME = "static-v1";
const ASSETS = [
    "/",
    "/index.html",
    "/manifest.json",
    "/app.css",
    "/_framework/blazor.webassembly.js",
    "/_framework/dotnet.wasm",
    "/icon-192.png",
    "/icon-512.png"
];

self.addEventListener("install", event => {
    console.log("✅ Service Worker instalado.");
    event.waitUntil(
        caches.open(CACHE_NAME).then(cache => {
            return cache.addAll(ASSETS);
        })
    );
});

self.addEventListener("fetch", event => {
    event.respondWith(
        caches.match(event.request).then(response => {
            return response || fetch(event.request);
        })
    );
});

self.addEventListener("activate", event => {
    // Limpieza de cachés antiguos
    event.waitUntil(
        caches.keys().then(keys =>
            Promise.all(
                keys.filter(key => key !== CACHE_NAME)
                    .map(key => caches.delete(key))
            )
        )
    );
});
