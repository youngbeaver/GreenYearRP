import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [plugin()],
    build: {
        outDir: "../../client_packages/cef",
        emptyOutDir: true
    },
    server: {
        port: 54850,
    }
})
