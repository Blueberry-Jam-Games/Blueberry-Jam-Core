#!/bin/bash
set -e

SOURCE_DIR="Assets/BJSamples"
DEST_DIR="Packages/blueberry-jam-core/Samples~"

# Check if source directory exists
if [ -d "$SOURCE_DIR" ]; then
    # Create destination directory if it doesn't exist
    mkdir -p "$DEST_DIR"
    
    # Copy files
    cp -r "$SOURCE_DIR"/* "$DEST_DIR"
    
    echo "Files copied from $SOURCE_DIR to $DEST_DIR"
else
    echo "Source directory $SOURCE_DIR does not exist."
    exit 1
fi
