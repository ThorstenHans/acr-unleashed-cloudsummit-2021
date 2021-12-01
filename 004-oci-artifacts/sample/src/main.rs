use std::{time, thread};

fn main() {

    loop {
        let d = time::Duration::from_secs(2);
        thread::sleep(d);
        println!("Hello from Rust 🦀");
    }
}
