const express = require('express');
const path = require('node:path');

const app = express();
const browserDistFolder = path.join(__dirname, 'dist', 'cargo-tech', 'browser');

app.use(express.static(browserDistFolder, { maxAge: '1y', index: false }));
app.get('*', (_request, response) => {
  response.sendFile(path.join(browserDistFolder, 'index.html'));
});

const port = process.env.PORT || 4000;
app.listen(port, () => {
  console.log(`CargoTech is serving on http://localhost:${port}`);
});
