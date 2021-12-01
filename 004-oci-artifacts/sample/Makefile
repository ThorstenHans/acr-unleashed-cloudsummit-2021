build:
	cargo build --target=wasm32-wasi --release
push:
	az acr login -n unleashed
	wasm-to-oci push ./target/wasm32-wasi/release/hello-wasm.wasm unleashed.azurecr.io/hello-wasm:latest
