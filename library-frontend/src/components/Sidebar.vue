<script setup>import { ref } from 'vue'

const showSidebar = ref(false)
const toggleSidebar = () => {
  showSidebar.value = !showSidebar.value
}</script>

<template>
    <!-- Hamburger button -->
    <button class="hamburger" @click="toggleSidebar">
        <i class="fas fa-bars"></i>
    </button>

    <!-- Sidebar -->
    <div v-if="showSidebar" class="sidebar">
        <button class="close-btn" @click="toggleSidebar">×</button>
        <nav>
            <h3 style="color:white;">Library</h3>
            <ul>
                <li><a href="#">Dashboard</a></li>
                <li><a href="#">Books</a></li>
                <li><a href="#">Borrowers</a></li>
                <li><a href="#">Settings</a></li>
            </ul>
        </nav>
    </div>
</template>

<style scoped>
    .hamburger {
        font-size: 22px;
        background: none;
        border: none;
        cursor: pointer;
        color: #0d1b2a; /* dark blue */
    }

    .sidebar {
        position: fixed;
        top: 0;
        left: 0;
        width: 260px;
        height: 100%;
        background: #0d1b2a; /* deep dark blue */
        color: #ffffff;
        box-shadow: 2px 0 12px rgba(0,0,0,0.2);
        padding: 24px; 
        display: flex;
        flex-direction: column;
        transition: transform 0.3s ease;
        font-family: "Segoe UI", sans-serif;
        z-index:2;
    }

    .close-btn {
        align-self: flex-end;
        background: none;
        border: none;
        font-size: 26px;
        color: #ffffff;
        cursor: pointer;
        margin-bottom: 20px;
    }

    .sidebar nav ul {
        list-style: none;
        padding: 0;
        margin: 0;
    }

    .sidebar nav li {
        margin: 16px 0;
    }

    .sidebar nav a {
        text-decoration: none;
        color: #ffffff;
        font-size: 15px;
        font-weight: 500;
        padding: 8px 12px;
        border-radius: 6px;
        display: block;
        transition: background 0.2s ease, color 0.2s ease;
    }

    .sidebar nav a:hover {
        background: #1b263b;
        color: #e0e0e0;
    }
</style>