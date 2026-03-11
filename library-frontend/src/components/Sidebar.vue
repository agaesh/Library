<script setup>import { ref } from 'vue'

const showSidebar = ref(false)
const toggleSidebar = () => {
  showSidebar.value = !showSidebar.value
    }

    const navbarItems = ["Dashboard", "Books", "Borrowers", "Settings"]

    const activeItem = ref(null);

    function setActive(item) {
        activeItem.value = item
    }
</script>

<template>
    <!-- Hamburger button -->
    <button class="hamburger" @click="toggleSidebar">
        <i class="fas fa-bars"></i>
    </button>

    <!-- Sidebar -->
    <div v-if="showSidebar" class="sidebar">
        <button class="close-btn" @click="toggleSidebar">×</button>
        <nav>
            <div class="brand">
                <h3>LIBRA</h3>
            </div>

            <ul>
                <li 
                    v-for="list in navbarItems" 
                    :key="list" 
                    :class="{ active: activeItem === list }"
                    @click = "setActive(list)">
                    <a>{{ list }}</a>
                </li>
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
        background: #ffffff;
        box-shadow: 2px 0 12px rgba(0,0,0,0.2);
        padding: 24px; 
        display: flex;
        flex-direction: column;
        transition: transform 0.3s ease;
        font-family: "Segoe UI", sans-serif;
        z-index:2;
    }

    .brand {
        display: flex; /* align logo + text if needed */
        align-items: center;
        font-weight: 700;
        font-size: 18px;
        color: #1d4ed8; /* brand blue */
        white-space: nowrap; /* prevent wrapping */
        background: none; /* remove background */
        border: none; /* no border */
        padding: 0; /* no extra spacing */
        margin: 0;
    }

    .close-btn {
        align-self: flex-end;
        background: none;
        border: none;
        font-size: 26px;
        color: darkblue;
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
        font-size: 15px;
        font-weight: 500;
        padding: 8px 12px;
        border-radius: 6px;
        display: block;
        transition: background 0.2s ease, color 0.2s ease;
    }

    .sidebar nav a:hover {
        background: rgba(0, 0, 0, 0.05); /* light transparent gray */
    }
    .active {
        background-color: #1d4ed8;
        font-weight: 600;
        box-shadow: 0 2px 6px rgba(29, 78, 216, 0.3);
        border-radius:20PX;
    }
    .active a{
      color:white;
    }
</style>